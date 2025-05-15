namespace countyourwordsTests.Tests;

[TestClass]
[DoNotParallelize]
public sealed class CountYourWordsTests
{   
    public string[] setInput(string s) {
        string tempFilePath = Path.GetTempFileName();
        File.WriteAllText(tempFilePath, s);
        File.Copy(tempFilePath, "input.txt", true);

        return Program.readFile("input.txt");
    }

    [TestMethod]
    public void TestExampleRead() {
        string[] input = setInput("….. The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123 !!");
        Assert.AreEqual(input.Length, 23);
    }

    [TestMethod]
    public void TestExampleSort() {
        string[] input = setInput("….. The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123 !!");
        string[] res = (string[])input.Clone();
        Array.Sort(res);
        Program.sortWords(input, 0, input.Length-1);
        CollectionAssert.AreEqual(input, res);
    }

    [TestMethod]
    public void TestExamplePair() {
        string[] input = setInput("….. The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123 !!");
        Program.sortWords(input, 0, input.Length-1);
        List<Pair<int, string>> pairs = Program.pairWords(input);
        List<Pair<int, string>> res = new List<Pair<int, string>> {
            new Pair<int, string>(3, "big"),
            new Pair<int, string>(3, "brown"),
            new Pair<int, string>(2, "dog"),
            new Pair<int, string>(3, "fox"),
            new Pair<int, string>(2, "jumped"),
            new Pair<int, string>(2, "lazy"),
            new Pair<int, string>(1, "number"),
            new Pair<int, string>(2, "over"),
            new Pair<int, string>(5, "the")
        };
        for (int i = 0; i < res.Count; i++) {
            Assert.AreEqual(res[i].First, pairs[i].First);
            Assert.AreEqual(res[i].Second, pairs[i].Second);
        } //compare each pair
    }

    [TestMethod]
    public void TestSimpleRead() {
        string[] input = setInput("the THE thE big BIG broWn THe big Brown FoX FoxX Brown The BIG Big Th3 Brown Fox");
        Assert.AreEqual(input.Length, 18);
    }

    [TestMethod]
    public void TestSimpleSort() {
        string[] input = setInput("the THE thE big BIG broWn THe big Brown FoX FoxX Brown The BIG Big Th3 Brown Fox");
        string[] res = (string[])input.Clone();
        Array.Sort(res);
        Program.sortWords(input, 0, input.Length-1);
        CollectionAssert.AreEqual(input, res);
    }

    [TestMethod]
    public void TestSimplePair() {
        string[] input = setInput("the THE thE big BIG broWn THe big Brown FoX FoxX Brown The BIG Big Th3 Brown Fox");
        Program.sortWords(input, 0, input.Length-1);
        List<Pair<int, string>> pairs = Program.pairWords(input);
        List<Pair<int, string>> res = new List<Pair<int, string>> {
            new Pair<int, string>(5, "big"),
            new Pair<int, string>(4, "brown"),
            new Pair<int, string>(2, "fox"),
            new Pair<int, string>(1, "foxx"),
            new Pair<int, string>(1, "th"),
            new Pair<int, string>(5, "the")
        };
        for (int i = 0; i < res.Count; i++) {
            Assert.AreEqual(res[i].First, pairs[i].First);
            Assert.AreEqual(res[i].Second, pairs[i].Second);
        } //compare each pair
    }

    [TestMethod]
    public void TestGibberishRead() {
        string[] input = setInput("CSKANOaxjiorcj aiopjcij12icj18!)! 9034viaisjxkoOKCaeokjcko csk'--anoa0841xjiorcj cjs8471092;[[';aca asciok*&^(#@joiv31v0dvlka ajocoIJV20vasca$#&$(!1) :CJS:ACA$@_+");
        Assert.AreEqual(input.Length, 8);
    }

    [TestMethod]
    public void TestGibberishSort() {
        string[] input = setInput("CSKANOaxjiorcj aiopjcij12icj18!)! 9034viaisjxkoOKCaeokjcko csk'--anoa0841xjiorcj cjs8471092;[[';aca asciok*&^(#@joiv31v0dvlka ajocoIJV20vasca$#&$(!1) :CJS:ACA$@_+");
        string[] res = (string[])input.Clone();
        Array.Sort(res);
        Program.sortWords(input, 0, input.Length-1);
        CollectionAssert.AreEqual(input, res);
    }

    [TestMethod]
    public void TestGibberishPair() {
        string[] input = setInput("CSKANOaxjiorcj aiopjcij12icj18!)! 9034viaisjxkoOKCaeokjcko csk'--anoa0841xjiorcj cjs8471092;[[';aca asciok*&^(#@joiv31v0dvlka ajocoIJV20vasca$#&$(!1) :CJS:ACA$@_+");
        Program.sortWords(input, 0, input.Length-1);
        List<Pair<int, string>> pairs = Program.pairWords(input);
        List<Pair<int, string>> res = new List<Pair<int, string>> {
            new Pair<int, string>(1, "aiopjcijicj"),
            new Pair<int, string>(1, "ajocoijvvasca"),
            new Pair<int, string>(1, "asciokjoivvdvlka"),
            new Pair<int, string>(2, "cjsaca"),
            new Pair<int, string>(2, "cskanoaxjiorcj"),
            new Pair<int, string>(1, "viaisjxkookcaeokjcko")  
        };
        for (int i = 0; i < res.Count; i++) {
            Assert.AreEqual(res[i].First, pairs[i].First);
            Assert.AreEqual(res[i].Second, pairs[i].Second);
        } //compare each pair
    }
}
