
namespace CompileInjectorTest
{

   

    [RegisterService]
    public class ClassWithDeps
    {
        public static ClassWithDeps InlinedConstructor()
        {
            return new ClassWithDeps(
                new NestedClass48(new NestedClass47(new NestedClass46(new NestedClass45(new NestedClass44(new NestedClass43(new NestedClass42(new NestedClass41(new NestedClass40(new NestedClass39(new NestedClass38(new NestedClass37(new NestedClass36(new NestedClass35(new NestedClass34(new NestedClass33(new NestedClass32(new NestedClass31(new NestedClass30(new NestedClass29(new NestedClass28(new NestedClass27(new NestedClass26(new NestedClass25(new NestedClass24(new NestedClass23(new NestedClass22(new NestedClass21(new NestedClass20(new NestedClass19(new NestedClass18(new NestedClass17(new NestedClass16(new NestedClass15(new NestedClass14(new NestedClass13(new NestedClass12(new NestedClass11(new NestedClass10(new NestedClass9(new NestedClass8(new NestedClass7(new NestedClass6(new NestedClass5(new NestedClass4(new NestedClass3(new NestedClass2(new NestedClass1(new NestedClass0())))))))))))))))))))))))))))))))))))))))))))))))),
                new NestedClass47(new NestedClass46(new NestedClass45(new NestedClass44(new NestedClass43(new NestedClass42(new NestedClass41(new NestedClass40(new NestedClass39(new NestedClass38(new NestedClass37(new NestedClass36(new NestedClass35(new NestedClass34(new NestedClass33(new NestedClass32(new NestedClass31(new NestedClass30(new NestedClass29(new NestedClass28(new NestedClass27(new NestedClass26(new NestedClass25(new NestedClass24(new NestedClass23(new NestedClass22(new NestedClass21(new NestedClass20(new NestedClass19(new NestedClass18(new NestedClass17(new NestedClass16(new NestedClass15(new NestedClass14(new NestedClass13(new NestedClass12(new NestedClass11(new NestedClass10(new NestedClass9(new NestedClass8(new NestedClass7(new NestedClass6(new NestedClass5(new NestedClass4(new NestedClass3(new NestedClass2(new NestedClass1(new NestedClass0()))))))))))))))))))))))))))))))))))))))))))))))),
                new NestedClass46(new NestedClass45(new NestedClass44(new NestedClass43(new NestedClass42(new NestedClass41(new NestedClass40(new NestedClass39(new NestedClass38(new NestedClass37(new NestedClass36(new NestedClass35(new NestedClass34(new NestedClass33(new NestedClass32(new NestedClass31(new NestedClass30(new NestedClass29(new NestedClass28(new NestedClass27(new NestedClass26(new NestedClass25(new NestedClass24(new NestedClass23(new NestedClass22(new NestedClass21(new NestedClass20(new NestedClass19(new NestedClass18(new NestedClass17(new NestedClass16(new NestedClass15(new NestedClass14(new NestedClass13(new NestedClass12(new NestedClass11(new NestedClass10(new NestedClass9(new NestedClass8(new NestedClass7(new NestedClass6(new NestedClass5(new NestedClass4(new NestedClass3(new NestedClass2(new NestedClass1(new NestedClass0())))))))))))))))))))))))))))))))))))))))))))))),
                new NestedClass45(new NestedClass44(new NestedClass43(new NestedClass42(new NestedClass41(new NestedClass40(new NestedClass39(new NestedClass38(new NestedClass37(new NestedClass36(new NestedClass35(new NestedClass34(new NestedClass33(new NestedClass32(new NestedClass31(new NestedClass30(new NestedClass29(new NestedClass28(new NestedClass27(new NestedClass26(new NestedClass25(new NestedClass24(new NestedClass23(new NestedClass22(new NestedClass21(new NestedClass20(new NestedClass19(new NestedClass18(new NestedClass17(new NestedClass16(new NestedClass15(new NestedClass14(new NestedClass13(new NestedClass12(new NestedClass11(new NestedClass10(new NestedClass9(new NestedClass8(new NestedClass7(new NestedClass6(new NestedClass5(new NestedClass4(new NestedClass3(new NestedClass2(new NestedClass1(new NestedClass0()))))))))))))))))))))))))))))))))))))))))))))),
                new NestedClass44(new NestedClass43(new NestedClass42(new NestedClass41(new NestedClass40(new NestedClass39(new NestedClass38(new NestedClass37(new NestedClass36(new NestedClass35(new NestedClass34(new NestedClass33(new NestedClass32(new NestedClass31(new NestedClass30(new NestedClass29(new NestedClass28(new NestedClass27(new NestedClass26(new NestedClass25(new NestedClass24(new NestedClass23(new NestedClass22(new NestedClass21(new NestedClass20(new NestedClass19(new NestedClass18(new NestedClass17(new NestedClass16(new NestedClass15(new NestedClass14(new NestedClass13(new NestedClass12(new NestedClass11(new NestedClass10(new NestedClass9(new NestedClass8(new NestedClass7(new NestedClass6(new NestedClass5(new NestedClass4(new NestedClass3(new NestedClass2(new NestedClass1(new NestedClass0()))))))))))))))))))))))))))))))))))))))))))))
                );
        }

        private NestedClass48 _foo48;
        private NestedClass47 _foo47;
        private NestedClass46 _foo46;
        private NestedClass45 _foo45;
        private NestedClass44 _foo44;
        public ClassWithDeps(
        NestedClass48 foo48
        , NestedClass47 foo47
        , NestedClass46 foo46
        , NestedClass45 foo45
        , NestedClass44 foo44
        )
        {
            _foo48 = foo48;
            _foo47 = foo47;
            _foo46 = foo46;
            _foo45 = foo45;
            _foo44 = foo44;
        }
    }

    [RegisterService]
    public class NestedClass0 { }

    [RegisterService]
    public class NestedClass1
    {
        private NestedClass0 _foo;
        public NestedClass1(NestedClass0 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass2
    {
        private NestedClass1 _foo;
        public NestedClass2(NestedClass1 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass3
    {
        private NestedClass2 _foo;
        public NestedClass3(NestedClass2 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass4
    {
        private NestedClass3 _foo;
        public NestedClass4(NestedClass3 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass5
    {
        private NestedClass4 _foo;
        public NestedClass5(NestedClass4 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass6
    {
        private NestedClass5 _foo;
        public NestedClass6(NestedClass5 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass7
    {
        private NestedClass6 _foo;
        public NestedClass7(NestedClass6 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass8
    {
        private NestedClass7 _foo;
        public NestedClass8(NestedClass7 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass9
    {
        private NestedClass8 _foo;
        public NestedClass9(NestedClass8 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass10
    {
        private NestedClass9 _foo;
        public NestedClass10(NestedClass9 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass11
    {
        private NestedClass10 _foo;
        public NestedClass11(NestedClass10 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass12
    {
        private NestedClass11 _foo;
        public NestedClass12(NestedClass11 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass13
    {
        private NestedClass12 _foo;
        public NestedClass13(NestedClass12 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass14
    {
        private NestedClass13 _foo;
        public NestedClass14(NestedClass13 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass15
    {
        private NestedClass14 _foo;
        public NestedClass15(NestedClass14 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass16
    {
        private NestedClass15 _foo;
        public NestedClass16(NestedClass15 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass17
    {
        private NestedClass16 _foo;
        public NestedClass17(NestedClass16 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass18
    {
        private NestedClass17 _foo;
        public NestedClass18(NestedClass17 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass19
    {
        private NestedClass18 _foo;
        public NestedClass19(NestedClass18 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass20
    {
        private NestedClass19 _foo;
        public NestedClass20(NestedClass19 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass21
    {
        private NestedClass20 _foo;
        public NestedClass21(NestedClass20 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass22
    {
        private NestedClass21 _foo;
        public NestedClass22(NestedClass21 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass23
    {
        private NestedClass22 _foo;
        public NestedClass23(NestedClass22 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass24
    {
        private NestedClass23 _foo;
        public NestedClass24(NestedClass23 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass25
    {
        private NestedClass24 _foo;
        public NestedClass25(NestedClass24 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass26
    {
        private NestedClass25 _foo;
        public NestedClass26(NestedClass25 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass27
    {
        private NestedClass26 _foo;
        public NestedClass27(NestedClass26 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass28
    {
        private NestedClass27 _foo;
        public NestedClass28(NestedClass27 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass29
    {
        private NestedClass28 _foo;
        public NestedClass29(NestedClass28 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass30
    {
        private NestedClass29 _foo;
        public NestedClass30(NestedClass29 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass31
    {
        private NestedClass30 _foo;
        public NestedClass31(NestedClass30 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass32
    {
        private NestedClass31 _foo;
        public NestedClass32(NestedClass31 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass33
    {
        private NestedClass32 _foo;
        public NestedClass33(NestedClass32 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass34
    {
        private NestedClass33 _foo;
        public NestedClass34(NestedClass33 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass35
    {
        private NestedClass34 _foo;
        public NestedClass35(NestedClass34 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass36
    {
        private NestedClass35 _foo;
        public NestedClass36(NestedClass35 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass37
    {
        private NestedClass36 _foo;
        public NestedClass37(NestedClass36 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass38
    {
        private NestedClass37 _foo;
        public NestedClass38(NestedClass37 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass39
    {
        private NestedClass38 _foo;
        public NestedClass39(NestedClass38 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass40
    {
        private NestedClass39 _foo;
        public NestedClass40(NestedClass39 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass41
    {
        private NestedClass40 _foo;
        public NestedClass41(NestedClass40 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass42
    {
        private NestedClass41 _foo;
        public NestedClass42(NestedClass41 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass43
    {
        private NestedClass42 _foo;
        public NestedClass43(NestedClass42 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass44
    {
        private NestedClass43 _foo;
        public NestedClass44(NestedClass43 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass45
    {
        private NestedClass44 _foo;
        public NestedClass45(NestedClass44 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass46
    {
        private NestedClass45 _foo;
        public NestedClass46(NestedClass45 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass47
    {
        private NestedClass46 _foo;
        public NestedClass47(NestedClass46 foo) { _foo = foo; }
    }

    [RegisterService]
    public class NestedClass48
    {
        private NestedClass47 _foo;
        public NestedClass48(NestedClass47 foo) { _foo = foo; }
    }
}


