### application topo
productpage -|-> review -> rating
             |-> detail

download jars  
```
wget http://edas.oss-cn-hangzhou.aliyuncs.com/edas-res/edas-lightweight-server-1.0.0.tar.gz
wget https://tli-dev.oss-cn-beijing.aliyuncs.com/rating.jar
wget https://tli-dev.oss-cn-beijing.aliyuncs.com/review.jar
wget https://tli-dev.oss-cn-beijing.aliyuncs.com/detail.jar
wget https://tli-dev.oss-cn-beijing.aliyuncs.com/productpage.jar
```

### start edas  
```
tar -zvxf edas-lightweight-server-1.0.0.tar.gz
sh edas-lightweight/bin/startup.sh
```

### start application  
```
java -jar app/rating.jar &
java -jar app/review.jar &
java -jar app/detail.jar &
java -jar app/productpage.jar &
```
check edas service status,open http://localhost:8080  


### testing  
```
curl http://localhost:4567/api/v1/products/1
curl http://localhost:4567/api/v1/products/1/review
```

### stop application
```
pkill -f "java -jar" 
sh edas-lightweight/bin/shutdown.sh
```

### for developers
* Java version: 1.8  
* Springboot:2.2.7
* Dubbo version
```
org.apache.dubbo:dubbo-spring-boot-starter:2.7.6
com.alibaba.edas:edas-dubbo-extension:2.0.6
```

