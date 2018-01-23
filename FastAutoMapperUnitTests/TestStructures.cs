
namespace Moon.FastAutoMapper.UnitTest
{
    public enum SimpleEnumSource{x,a,b,c,d,y,t}
    public enum SimpleEnumDestination { b, c, d,a,f }
    public enum SimpleEnumLongSource:long {
        b =long.MaxValue,
        c =long.MinValue,
        d = long.MinValue+1,
        a = long.MaxValue-1,
        f =0,
        g =2,
        t=333
    }
    public class SimpleSourceClass
    {
        public int a;
        public SourceClassWithoutDefaultConstructor k = new SourceClassWithoutDefaultConstructor(1);
    }
    public class SimpleDestinationClass
    {
        public int a;
        public DestinationClassWithoutContructor k;
    }
    public struct SimpleSourceStruct
    {
        public SimpleSourceClass c;
    }
    public struct SimpleDestinationStruct
    {
        public SimpleDestinationClass c;
    }

    public class SourceClassWithoutDefaultConstructor
    {
        public int i = 2;
        public SourceClassWithoutDefaultConstructor(int _i)
        {
            i = _i;
        }

    }
    public class DestinationClassWithoutContructor
    {
        public int i = 2;
        public DestinationClassWithoutContructor(int _i)
        {
            i = _i;
        }
    }

    public  class SourcePoint
    {

        public int x;
        public string y;
        public object a;
        public SimpleEnumSource k;
        public override string ToString()
        {
            return $"x={x},y={y}";
        }
    }
    public class DestinationPoint
    {
        public int x;
        public double y;
        public int a;
        public long k;

    }
    public struct SourceStructPoint
    {

        public int x;
        public string y;
        public object a;
        public SourcePoint px;
    }
    public struct DestinationStructPoint
    {
        public int x;
        public double y;
        public object a;
        public DestinationPoint px;

    }
    public class SourceClassWithAutoProperty
    {
        public int x { get; set; }
        public double y { get; set; }
        public string z { get; set; }
    }
    public class DestinationClassWithAutoProperty
    {
        public int x { get; set; }
        public decimal y { get; set; }
        public double z { get; set; }
    }
    public class ClassWithIntArray
    {
        public int[] list;
    }
    public class ClassWithEnumField
    {
        public SimpleEnumSource type;
    }
    public class ClassWithStringField
    {
        public string type;
    }
    public class ClassWithStructField
    {
        public SourcePointStruct type;
    }
    public class ClassWithIntField
    {
        public int type;
    }
    public class ClassWithStringArray
    {
        public string[] list;
    }
    public class ClassWithObjectField
    {
        public object type;
    }
    public class SourcePointClass
    {
        public int x { get; set; }
        public double y { get; set; }
    }

    public class DestinationPointClass
    {
        public int x { get; set; }
        public double y { get; set; }
    }
    public struct SourcePointStruct
    {
        public int x { get; set; }
        public double y { get; set; }
    }

    public struct DestinationPointStruct
    {
        public int x { get; set; }
        public double y { get; set; }
    }
    public class FirstCircularClass
    {
        public int i;
        public FirstCircularClass parent;
    }
    public class SecondCircularClass
    {
        public int i;
        public SecondCircularClass parent;
    }

    public class SourceBaseClass
    {
        public int x;
    }

    public class SourceDerivedClass : SourceBaseClass
    {
        public int y;
    }
    public class DestinationBaseClass
    {
        public int X;
    }

    public class DestinationDerivedClass : DestinationBaseClass
    {
        public int Y;
    }
    public class SourceBaseClassWithProperty
    {
        public int x { get; set; }
    }

    public class SourceDerivedClassWithProperty : SourceBaseClassWithProperty
    {
        public int y { get; set; }
    }
    public class DestinationBaseClassWithProperty
    {
        public int X { get; set; }
    }

    public class DestinationDerivedClassWithProperty : DestinationBaseClassWithProperty
    {
        public int Y { get; set; }
    }
    public class EmptyClass
    {
    }

    public class SourceAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
    public class DestinationAddress
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
    }
    public class SourcePerson
    {
        public SourcePerson(string lastname, string firstname)
        {
            this.LASTNAME = lastname;
            this.FIRSTNAME = firstname;
        }
        private string LASTNAME;
        private string FIRSTNAME;
        public SourceAddress Address;
        public override string ToString()
        {
            return LASTNAME + " " + FIRSTNAME;
        }
    }
    public class DestinationPerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DestinationAddress Address { get; set; }
    }
}

