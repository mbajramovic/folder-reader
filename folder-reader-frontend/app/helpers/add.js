import { helper } from '@ember/component/helper';

function add(params) {
  return params[0] + params[1];
}

export default helper(add);
