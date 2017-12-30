
namespace Moon.FastAutoMapper.UnitTest
{
    public enum SimpleEnumSource{x,a,b,c,d,y}
    public enum SimpleEnumDestination { b, c, d,a,f }

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

}

