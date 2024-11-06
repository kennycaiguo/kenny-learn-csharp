using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace call_base_class_event
{
    public class ShapeEventArgs : EventArgs
    {
        private double newArea;
        public ShapeEventArgs(double area) 
        { 
            this.newArea = area;
        }
        public double NewArea
        {
            get { return newArea; }
        }
    }

    //抽象基类
    public abstract class Shape
    {
        protected double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
           
        //声明泛型事件
        public event EventHandler<ShapeEventArgs> ShapeChanged;
        public abstract void Draw();//抽象方法
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            EventHandler<ShapeEventArgs> handler = ShapeChanged;
            if(handler != null) handler(this, e);
        }
    }

    //圆形子类
    public class Circle:Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
            area = 3.14 * radius * radius;
            this.ShapeChanged += HandleShapeChange;
        }

        private void HandleShapeChange(object sender, ShapeEventArgs e)
        {
            Shape s = (Shape)sender;
            Console.WriteLine("Update event,the area is now {0}",e.NewArea);
            s.Draw();
        }

        public void Update(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            //可以在这里添加额外的处理代码\

            //调用基类的事件处理函数
            base.OnShapeChanged(e);
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle,area is {0}",area);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(25.0);
            c.Update(100.0);
        }
    }
}
