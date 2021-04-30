import http from 'k6/http';
import { sleep } from 'k6';
import { check } from 'k6';
export let options = {
    vus:100,
    duration:"10s"
  };
export default function () {

  let res = http.get("http://10.208.20.73:5000/api/values/getfromredis?key=test");
  check(res,{"is status 200":(r)=>r.status === 200,});
  console.log(res.status) 
  sleep(1);
}