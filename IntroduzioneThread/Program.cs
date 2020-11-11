using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //NECESSARIO A LAVORARE CON I THREAD

namespace IntroduzioneThread
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Prima dell avvio dei thread");
            //istanzio la classe che contiene i metodi da associare ai thread
            MyThread tr1 = new MyThread();

            //creo due thread associati ai due metodi della classe MyThread
            Thread t1 = new Thread(new ThreadStart(tr1.Thread1));            //ThreadStart è un delegate
            Thread t2 = new Thread(new ThreadStart(tr1.Thread2));

            //avvio thread
            t1.Start(); //il metodo start equivale al fork
            t1.Join(); //prima di procedere con il codice sottostante attendo la fine del thread t1
            t2.Start();

            for(int i = 0; i < 100; i++)
            {

                Console.WriteLine("Main {0}", i);

            }

           /* try
            {

                t1.Abort(); //Uccisione di un thread (attenzione a utilizzarlo perchè può essere non supportato e potrebbe generare eccezioni)

            }
            catch(Exception ex)
            {

                Console.WriteLine("Errore nell'uccisione nel thread1: {0}", ex.Message);

            }
           */

            Console.ReadLine();

        }

    }

    public class MyThread //classe che contiene i thread da lanciare
    {

        public void Thread1() //i thread sono metodi void e nessun parametro
        {

            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("Thread 1 {0}", i);

            }

        }

        public void Thread2() //i thread sono metodi void e nessun parametro
        {

            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("Thread 2 {0}", i);

            }

        }

    }
}
