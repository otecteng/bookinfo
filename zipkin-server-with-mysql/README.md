# Sample of Zipkin Server with MySQL as storage

## How to use this?

1. Replace `path` in Volumes with path from your local
2. Run `docker network create zipkin_net` to create the network
3. `docker-compose up -d`
4. Run `docker ps`, you should see two containers running (zipkin_server & zipkin_mysql)
5. Navigate `http://localhost:9411`, you should see the main page of zipkin

## Initialize zipkin mysql database

1. `SET GLOBAL innodb_file_format=Barracuda`
2. `show global variables like 'innodb_file_format'` check whether it's successfully setup or not 
3. Run sql from [OpenZipkin](https://raw.githubusercontent.com/openzipkin/zipkin/master/zipkin-storage/mysql-v1/src/main/resources/mysql.sql) to initialize the schema

## Check the tracing data

```
SELECT lower(concat(CASE trace_id_high
                        WHEN '0' THEN ''
                        ELSE hex(trace_id_high)
                    END,hex(trace_id))) AS trace_id,
       lower(hex(parent_id)) as parent_id,
       lower(hex(id)) as span_id,
       name,
       from_unixtime(start_ts/1000000) as timestamp
FROM zipkin_spans
where (start_ts/1000000) > UNIX_TIMESTAMP(now()) - 5 * 60;
```