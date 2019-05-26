grammar Doggolang;

options {
	language=CSharp;
}

program
	:	statements? returnStatement EOF
	;

returnStatement
	:	expr NL?
	;

statements
	:	statement+
	;

statement
	:	assignmentStatement
	|	ifThenBlock
	|	ifThenElseBlock
	|	whileDoBlock
	;
	
assignmentStatement
	:	name=ID ASSIGN value=expr NL
	;

ifStatement
	:	IF condition=relationalExpr THEN NL
	;

ifThenBlock
	:	ifStatement body=statements endIfStatement
	;
	
ifThenElseBlock
	:	ifStatement body=statements elseStatement elseBody=statements endIfStatement
	;

elseStatement
	:	ELSE NL
	;

endIfStatement
	:	ENDIF NL
	;
	
expr
	:	lhs=expr op=MUL rhs=expr #mulExpr
	|	lhs=expr op=(ADD|SUB) rhs=expr #addSubExpr
	|	name=ID #variableExpr
	|	value=INT #constantExpr
	;

relationalExpr
	:	lhs=expr op=LT rhs=expr
	|	lhs=expr op=GT rhs=expr
	;
	
whileDoBlock
	: whileDoStatement statements loopStatement
	;
	
whileDoStatement
	:	WHILE condition=relationalExpr DO NL
	;

loopStatement
	: LOOP NL
	;

// LEXER

ASSIGN : 'AWOO';
ADD : 'WOOF';
IF : 'RUF?';
GT : 'YAP';
THEN : 'VUH';
MUL : 'ARF';
ELSE : 'ROWH';
ENDIF : 'ARRUF';
LT : 'YIP';
SUB : 'BARK';
WHILE : 'GRRR';
DO : 'BOW';
LOOP : 'BORF';

INT	: [0-9]+ ;
ID : [a-z]+ ;
NL : '\r'? '\n' ;
WS : ' ' -> skip;