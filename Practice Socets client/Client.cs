
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Practice_Socets_client
{
    /*Разработайте два консольных приложения, использующих сокеты. Одно приложение — сервер, второе — клиент. Клиентское приложение посылает приветствие серверу. Сервер отвечает. И клиент, и сервер отображают полученное сообщение. Пример вывода:*/
    public class Client
    {
        Socket Sock;
        public event Action<string>? Reseive;
        public string StopWord = "<Bye>";

        private SynchronizationContext _uiContext = null;//winforms

        public Client(SynchronizationContext uiContext = null)
        {
            _uiContext = uiContext ?? new SynchronizationContext();
        }
        private void Log(string msg)
        {
            if (_uiContext != null)
                _uiContext.Post(d => Reseive?.Invoke(msg), null);
            else
                Reseive?.Invoke(msg);
        }

        public void CloseSock()
        {
            try
            {
                Sock?.Shutdown(SocketShutdown.Both);
            }
            catch 
            {
            //nothing
            }
            Sock?.Close();

        }
        public void Connect(string ip = "127.0.0.1", int port = 4000)
        {
            try
            {
                IPAddress ipAdress = IPAddress.Parse(ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAdress /* IP-адрес */, port /* порт */);

                Sock = new Socket(AddressFamily.InterNetwork /*схема адресации*/, SocketType.Stream /*тип сокета*/, ProtocolType.Tcp /*протокол*/);
                Sock.Connect(ipEndPoint);
                byte[] msg = Encoding.UTF8.GetBytes(Dns.GetHostName() /* имя узла локального компьютера */);// конвертируем строку, содержащую имя хоста, в массив байтов
                int bytesSent = Sock.Send(msg); // отправляем серверу сообщение через сокет
                Log("Клиент " + Dns.GetHostName() + " установил соединение с " + Sock.RemoteEndPoint?.ToString());

                Thread receiveThread = new Thread(Recieve);
                receiveThread.IsBackground = true;
                receiveThread.Start();

            }
            catch (Exception ex)
            {
                Log(ex.Message.ToString());

            }

        }

        public void Send(string msg_)
        {
            try
            {
                if (Sock == null || !Sock.Connected) { return; }
                byte[] msg = Encoding.UTF8.GetBytes(msg_!);
                int bytesSent = Sock.Send(msg); // отправляем серверу сообщение через сокет
                //Log(bytesSent.ToString());

            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        public void Recieve()
        {
            try
            {
                string data = null;
                byte[] bytes = new byte[1024];// max amount to transfer data buffer
                while (true)
                {
                    int bytesRec = Sock.Receive(bytes);
                    if (bytesRec == 0)
                    {
                        //sock.Shutdown(SocketShutdown.Both);
                        //sock.Close();
                        break;
                    }
                   
                    data = Encoding.UTF8.GetString(bytes, 0, bytesRec); // конвертируем массив байтов в строку
                    if (data.IndexOf(StopWord) > -1)
                    {
                        break;
                    }
                    Log(data);
                }
            }
            catch (SocketException)
            {
                //nothing all in fin
            }
            catch (Exception ex)
            {
                Log(ex.Message.ToString());
            }

        }



    }
}
