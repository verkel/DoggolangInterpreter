using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using DoggolangInterpreter.Generated;

namespace DoggolangInterpreter {
	public class Interpreter : DoggolangBaseVisitor<int> {
		private Dictionary<string, int> variables = new Dictionary<string,int>();
		
		public static int Eval(ICharStream input) {
			var lexer = new DoggolangLexer(input);
			var tokens = new CommonTokenStream(lexer);
			var parser = new DoggolangParser(tokens);
			var tree = parser.program();

			return new Interpreter().Visit(tree);
		}

		public override int VisitProgram(DoggolangParser.ProgramContext context) {
			Visit(context.statements());
			return Visit(context.returnStatement());
		}

		public override int VisitAssignmentStatement(DoggolangParser.AssignmentStatementContext context) {
			var name = context.name.Text;
			var value = Visit(context.value);
			variables[name] = value;
			return 0;
		}

		public override int VisitMulExpr(DoggolangParser.MulExprContext context) {
			return Visit(context.lhs) * Visit(context.rhs);
		}

		public override int VisitAddSubExpr(DoggolangParser.AddSubExprContext context) {
			switch (context.op.Type) {
				case DoggolangParser.ADD: return Visit(context.lhs) + Visit(context.rhs);
				case DoggolangParser.SUB: return Visit(context.lhs) - Visit(context.rhs);
				default: return 0;
			}
		}

		public override int VisitVariableExpr(DoggolangParser.VariableExprContext context) {
			return variables.TryGetValue(context.name.Text, out var value) ? value : 0;
		}

		public override int VisitConstantExpr(DoggolangParser.ConstantExprContext context) {
			return int.Parse(context.value.Text);
		}

		public override int VisitRelationalExpr(DoggolangParser.RelationalExprContext context) {
			return Convert.ToInt32(EvaluateRelationalExpr(context));
		}

		private bool EvaluateRelationalExpr(DoggolangParser.RelationalExprContext context) {
			switch (context.op.Type) {
				case DoggolangParser.LT: return Visit(context.lhs) < Visit(context.rhs);
				case DoggolangParser.GT: return Visit(context.lhs) > Visit(context.rhs);
				default: return false;
			}
		}
		
		public override int VisitIfThenBlock(DoggolangParser.IfThenBlockContext context) {
			if (EvaluateRelationalExpr(context.ifStatement().condition)) {
				return Visit(context.body);
			}
			return 0;
		}

		public override int VisitIfThenElseBlock(DoggolangParser.IfThenElseBlockContext context) {
			if (EvaluateRelationalExpr(context.ifStatement().condition)) {
				return Visit(context.body);
			}
			else {
				return Visit(context.elseBody);
			}
		}

		public override int VisitWhileDoBlock(DoggolangParser.WhileDoBlockContext context) {
			while (EvaluateRelationalExpr(context.whileDoStatement().condition)) {
				Visit(context.statements());
			}
			return 0;
		}
	}
}