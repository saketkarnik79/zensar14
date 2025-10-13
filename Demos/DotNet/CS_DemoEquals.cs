using System;

namespace CS_DemoEquals
{
	class Person
	{
		public string name;
		
		public override bool Equals(object obj)
		{
			if(obj is Person)
			{
				Person p=obj as Person;
				return this.name == p.name;
			}
			return false; 
		}
		
		public override int GetHashCode()
		{
			return name.GetHashCode();
		}
		
		public static bool operator ==(Person p1, Person p2)
		{
			return p1.name == p2.name;
		}
		public static bool operator !=(Person p1, Person p2)
		{
			return !(p1.name == p2.name);
		}
	}
	
	class Program
	{
		static void Main()
		{
			Person per1=new Person();
			per1.name= "James";
			
			Person per2 =new Person();
			per2.name = "James Bond";
			
			Console.WriteLine("Equals(): {0}, HashCode: {1}, {2}", per1.Equals(per2), per1.GetHashCode(), per2.GetHashCode());
			Console.WriteLine("==: {0}", per1==per2);
			
			Console.WriteLine("Program Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}