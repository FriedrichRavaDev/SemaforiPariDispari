using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semafori
{
    class EvenOddNumbers
    {
        Form1 form;
        static Semaphore semaphorePari = new Semaphore(1, 1);
        static Semaphore semaphoreDispari = new Semaphore(0, 1);

        public EvenOddNumbers(Form1 form1)
        {
            form = form1;
        }

        public void Pari()
        {
            Thread t1 = new Thread(Even);
            t1.Start();
        }

        public void Dispari()
        {
            Thread t2 = new Thread(Odd);
            t2.Start();
        }

        public void Even()
        {
            int n = 0;

            while (true)
            {
                semaphorePari.WaitOne(); //parte da 1, passa, e si setta a 0;

                //n = 2 * n; //numeri pari;
                //s1 = 0;

            //    Thread.Sleep(1000);
                form.Invoke(new Action(() => form.AggiornaListBox("Thread pari:" + n)));
                Thread.Sleep(1000);
                form.Invoke(new Action(() => form.AggiornaListBox($"Thread pari acquisisce il semaforo alle {DateTime.Now.Millisecond}")));

                n +=2;

                semaphoreDispari.Release(); //si setta a 1;

            }

        }

        public void Odd()
        {
            int n = 1;

            while (true)
            {
                semaphoreDispari.WaitOne(); //parte da 1, passa, e si setta a 0;

                //n = 2 * (n + 1); //numeri dispari;

               // Thread.Sleep(1000);
                form.Invoke(new Action(() => form.AggiornaListBox("Thread dispari:" + n)));
                Thread.Sleep(1000);
                form.Invoke(new Action(() => form.AggiornaListBox($"Thread dispari acquisisce il semaforo alle {DateTime.Now.Millisecond}")));

                n = n + 2;

                semaphorePari.Release();
            }
        }
    }
}
