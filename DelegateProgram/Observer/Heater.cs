using System;

namespace DelegateProgram.Observer
{

    
    public class Heater
    {
        public int Temperature { get; set; }

        public event Action<int> OnBoild;
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                Temperature = i;
                if (Temperature > 95)
                {
                    MakeAlert(Temperature);
                    ShowMsg(Temperature);
                }
            }
        }

        public void MakeAlert(int parm)
        {
            Console.WriteLine($"Alarm-滴滴滴-水已经 {parm} ℃了");
        }

        public void ShowMsg(int parm)
        {
            Console.WriteLine($"Display-水块开了，当前温度: {parm} ℃了");
        }
    }


    public class AssembleHeater
    {
        public int Temperature { get; set; }

        public event Action<int> OnBoild;
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                Temperature = i;
                if (Temperature > 95)
                {
                    OnBoild?.Invoke(Temperature);  // 依次调用所有注册对象的方法
                    Console.WriteLine($"组装热水器-{Temperature}℃");
                }
            }
        }
    }

    public class Alarm
    {
        public  void MakeAlert(int parm)
        {
            Console.WriteLine($"Alarm-滴滴滴-水已经 {parm} ℃了");
        }
    }

    public class Display
    {
        public static void ShowMsg(int parm)
        {
            Console.WriteLine($"Display-水快开了，当前温度: {parm} ℃了");
        }
    }
}
