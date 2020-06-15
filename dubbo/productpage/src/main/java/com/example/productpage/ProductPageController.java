package com.example.productpage;

import com.example.detail.IDetail;
import com.example.review.IReview;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.apache.dubbo.config.annotation.Reference;

@RestController
public class ProductPageController {
    @Reference
    private IDetail detailService;
    @Reference
    private IReview reviewService;

    @RequestMapping(value="/index",method= RequestMethod.GET)
    public String say(){
        return "index";
    }
    @RequestMapping(value="/health",method= RequestMethod.GET)
    public String health(){
        return "health";
    }
    @RequestMapping(value="/login",method= RequestMethod.GET)
    public String login(){
        return "login";
    }
    @RequestMapping(value="/logout",method= RequestMethod.GET)
    public String logout(){
        return "logout";
    }
    @RequestMapping(value="/productpage",method= RequestMethod.GET)
    public String prouductpage(){
        return "prouductpage";
    }
    @RequestMapping(value="/api/v1/products/{id}",method= RequestMethod.GET)
    public String detail(@PathVariable int id){
        return detailService.detail("");
    }
    @RequestMapping(value="/api/v1/products/{id}/review",method= RequestMethod.GET)
    public String review(@PathVariable int id){
        return reviewService.review(1);
    }

    @RequestMapping(value="/api/v1/products/{id}/rating",method= RequestMethod.GET)
    public String rating(@PathVariable int id){
        return "rating";
    }
}
