using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            people p1=new people();
            p1.first_name = "Donald";
            p1.last_name = "trump";
            p1.dob = new DateTime(1946, 6, 14);

            people p2 = new people();
            p2.first_name = "Ted";
            p2.last_name = "cruz";
            p2.dob = new DateTime(1970, 12, 22);

            people p3 = new people();
            p3.first_name = "Hillary";
            p3.last_name = "clinton";
            p3.dob = new DateTime(1947, 10, 26);

    
            YourQueue MyPeople = new YourQueue();

            MyPeople.queue.Enqueue(p1);

            MyPeople.queue.Enqueue(p2);

            MyPeople.queue.Enqueue(p3);

            MyPeople.queue.Enqueue("Micky mouse");


            Object itm = MyPeople.queue.Peek();
      

            for (int i = 0; i < 4; i++)
            {
                if ((MyPeople.queue.Peek()).GetType().ToString().Contains("people"))
                {
                    MyPeople.Dequeue();
                }
                else
                {
                    MyPeople.Dequeue();
                }
            }
        }
    }


    public class people
    {
        [ReadOnly(true)]
        public string first_name;
        [ReadOnly(true)]
        public string last_name;
        [ReadOnly(true)]
        public DateTime dob;
    }
    class YourQueue
    {
        public object itm;
        public Queue queue = new Queue();
        public event EventHandler Changed;
        protected virtual void OnChanged()
        {
            if (itm.GetType().ToString().Contains("people"))
            {
                DateTime current = DateTime.Now;              
                DateTime bday = ((people)itm).dob;
                DateTime temp = bday.AddYears(current.Year - bday.Year);
                if (temp < current)
                    temp.AddYears(1);
                int totaldays = (temp - current).Days;
                MessageBox.Show("You sucessfully dequeued " + ((people)itm).first_name.ToString() + " " + ((people)itm).last_name.ToString() + Environment.NewLine + "\n His Birthday is on " + ((people)itm).dob.ToString("MM/dd/yyyy") + Environment.NewLine + totaldays + " Days remaining for his next Birthdayparty.");
            }
            else
            {
                MessageBox.Show("You sucessfully dequeued " + itm .ToString()+ " who is not a person");
            }
            
            if (Changed != null) Changed(this, EventArgs.Empty);
        }
        public virtual  void Dequeue()
        {
            itm = queue.Dequeue();
            OnChanged();
          
        }
    }

}

 