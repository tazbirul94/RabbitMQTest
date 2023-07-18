using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672"); // post is taken fromt he docker image
factory.ClientProvidedName = "Rabbit Sender App"; //name for the rabbitmq application

IConnection conn = factory.CreateConnection();

IModel channel = conn.CreateModel();

string exchangeName = "DemoExchange";
string routingKey = "demo-routing-key";
string queueName = "DemoQueue";

channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
channel.QueueDeclare(queueName, false, false, false, null);
channel.QueueBind(queueName, exchangeName, routingKey, null);

byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello World"); //when you send a message though a broker always send bytes
channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

channel.Close(); // best practice is to close the channel first
conn.Close();
