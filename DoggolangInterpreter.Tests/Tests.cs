using NUnit.Framework;

namespace DoggolangInterpreter {
	
	public class Tests {

// This is what we know:
    
[TestCase(11, 
@"lassie AWOO 5
luna AWOO 6
bailey AWOO lassie WOOF luna
bailey"
)]

[TestCase(15, 
@"roi AWOO 5
RUF? roi YAP 2 VUH
  roi AWOO roi ARF 3
ROWH
  roi AWOO roi WOOF 100
ARRUF
roi"
)]

[TestCase(105, 
@"roi AWOO 5
RUF? roi YIP 2 VUH
  roi AWOO roi ARF 3
ROWH
  roi AWOO roi WOOF 100
ARRUF
roi"
)]

[TestCase(19,
@"quark AWOO 6 BARK 2
gromit AWOO 5
milo AWOO 0
GRRR milo YIP gromit BOW
    quark AWOO quark WOOF 3
    milo AWOO milo WOOF 1
BORF
quark"
)]

// Please run this very important code and return the result and your interpreter source code to us as soon as possible:

[TestCase(42,
@"samantha AWOO 1
hooch AWOO 500
einstein AWOO 10
fuji AWOO 0
GRRR fuji YIP hooch BOW
    samantha AWOO samantha WOOF 3
    RUF? samantha YAP 100 VUH
      samantha AWOO samantha BARK 1
    ROWH
      einstein AWOO einstein WOOF 1
      samantha AWOO samantha ARF einstein
    ARRUF
    fuji AWOO fuji WOOF 1
BORF
GRRR fuji YAP 0 BOW
    samantha AWOO samantha WOOF 375
    fuji AWOO fuji BARK 3
BORF
samantha"
)]

		public void TestProgram(int expectedReturnVal, string text) {
			var returnVal = Interpreter.Eval(text);
			Assert.AreEqual(expectedReturnVal, returnVal);
		}
	}
}