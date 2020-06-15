package com.example.review;

import com.example.rating.IRating;
import org.apache.dubbo.config.annotation.Reference;
import org.apache.dubbo.config.annotation.Service;

@Service
public class IReviewImpl implements IReview {
    @Reference
    private IRating ratingService;

    @Override
    public String review(int id) {
        ratingService.rating(1);
        return "review message from review service";
    }
}
