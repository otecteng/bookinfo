FROM openjdk:8-alpine

ARG NAME=order
ARG VERSION=1.0.0
ARG JAR_FILE=order.jar

LABEL name=$NAME \
      version=$VERSION

ENV RABBITMQ=rabbitmq
ENV TZ=Asia/Shanghai
RUN set -eux; \
    ln -snf /usr/share/zoneinfo/$TZ /etc/localtime; \
    echo $TZ > /etc/timezone


RUN set -eux; \
    addgroup --gid 1000 java-app; \
    adduser -S -u 1000 -g java-app -h /home/java-app/ -s /bin/sh -D java-app; \
    mkdir -p /home/java-app/lib /home/java-app/etc /home/java-app/jmx-ssl /home/java-app/logs /home/java-app/tmp /home/java-app/jmx-exporter/lib /home/java-app/jmx-exporter/etc; \
    chown -R java-app:java-app /home/java-app


COPY --chown=java-app:java-app docker-entrypoint.sh /home/java-app/docker-entrypoint.sh


COPY --chown=java-app:java-app build/libs/${JAR_FILE} /home/java-app/lib/app.jar

USER java-app

ENTRYPOINT ["/home/java-app/docker-entrypoint.sh"]

EXPOSE 8080