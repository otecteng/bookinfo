import http from 'k6/http';
import { sleep } from 'k6';
import { check } from 'k6';
export let options = {
    vus:200,
    duration:"15s"
  };
export default function () {

  let res = http.get('http://10.208.20.73:80');
  check(res,{"is status 200":(r)=>r.status === 200,});
//   check(res,{"is status 503":(r)=>r.status === 503,});
  sleep(1);
}