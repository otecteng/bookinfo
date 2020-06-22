# Tutorial

1. in Skywalking folder, run `docker-compose up -d` to start all skywalking needed services. (in this sample, we use elastic-search as backend service)
2. when start business service use below command
`java -jar -javaagent:$AGENT_PATH/skywalking-agent.jar -Dskywalking.agent.service_name=dubbo-rating -Dskywalking.collector.servers=localhost:10800 rating.jar`