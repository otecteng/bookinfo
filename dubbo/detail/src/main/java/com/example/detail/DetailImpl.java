package com.example.detail;

import org.apache.dubbo.config.annotation.Service;

@Service
public class DetailImpl implements IDetail{
    public String detail(String str){
        return "message from detail service";
    }
}
