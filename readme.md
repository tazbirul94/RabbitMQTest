1. First pull a docker image 
docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management
and then login to the localhost:8080		
username: guest
password: guest

2. Now go to your project and install rabbitmq.client using nuget packager