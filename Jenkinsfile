pipeline{
    agent any
    stages{
        stage("build"){
            steps{
                echo "========executing build========"

            }
            post{
                always{
                    echo "========always========"
                }
                success{
                    echo "========build stage executed successfully========"
                }
                failure{
                    echo "========build stage execution failed========"
                }
            }
        }
        stage("test"){
            steps{
                echo "========executing test========"
            }
            post{
                always{
                    echo "========always========"
                }
                success{
                    echo "========test stage executed successfully========"
                }
                failure{
                    echo "========test stage execution failed========"
                }
            }
        }
        stage("deploy"){
            steps{
                echo "========executing deploy========"
            }
            post{
                always{
                    echo "========always========"
                }
                success{
                    echo "========deploy stage executed successfully========"
                }
                failure{
                    echo "========deploy stage execution failed========"
                }
            }
        }
    }
    post{
        always{
            echo "========always========"
        }
        success{
            echo "========pipeline executed successfully ========"
        }
        failure{
            echo "========pipeline execution failed========"
            //sudo docker run -p 80:80 -v /nginx/nginx.conf:/etc/nginx/nginx.conf -v /nginx/nginx/conf.d:/etc/nginx/conf.d -v /nginx/log:/var/log/nginx -d registry.cn-hangzhou.aliyuncs.com/book_info/gateway:1.0
        }
    }
}