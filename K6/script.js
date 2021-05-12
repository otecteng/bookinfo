import http from 'k6/http';
import { sleep } from 'k6';
import { check } from 'k6';
import { Counter } from 'k6/metrics';

var _status_200 = new Counter("_status_200");
var _total_req = new Counter("_total_req"); 
export let options = {
    vus:30,
    duration:"15s"
  };
export default function () {

  let res = http.get("http://40.73.86.145/api/values/getfromredis?key=test");
  check(res,{"is status 200":(r)=>r.status === 200,
    "is status 204":(r)=>r.status === 204,
    "is status 400":(r)=>r.status === 400,
    "is status 401":(r)=>r.status === 401,
    "is status 403":(r)=>r.status === 403,
    "is status 404":(r)=>r.status === 404,
    "is status 500":(r)=>r.status === 500,
    "is status 501":(r)=>r.status === 501,
    "is status 502":(r)=>r.status === 502,
    "is status 503":(r)=>r.status === 503
  }); 

  //添加Counter
  if (res.status === 200){
    _status_200.add(1);
  }
  _total_req.add(1);
  sleep(1);
}