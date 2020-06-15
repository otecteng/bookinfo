package com.example.rating;
import org.apache.dubbo.config.annotation.Service;

@Service
public class IRatingImpl implements IRating {
    @Override
    public int rating(int id) {
        return 0;
    }
}
