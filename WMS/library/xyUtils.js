var sy = sy || {};

/**
 * 去字符串空格
 */
sy.trim = function (str) {
    return str.replace(/(^\s*)|(\s*$)/g, '');
};
sy.ltrim = function (str) {
    return str.replace(/(^\s*)/g, '');
};
sy.rtrim = function (str) {
    return str.replace(/(\s*$)/g, '');
};


/**
将form表单元素的值序列化成对象
 */
sy.serializeObject = function (form) {
    var o = {};
    $.each(form.serializeArray(), function (index) {
        if (this['value'] && this['value'].length > 0) {// 如果表单项的值非空，才进行序列化操作
            if (o[this['name']]) {
                o[this['name']] = o[this['name']] + "," + this['value'];
            } else {
                o[this['name']] = this['value'];
            }
        }
    });
    return o;
};


/**
 * 增加formatString功能
 * @example sy.formatString('字符串{0}字符串{1}字符串','第一个变量','第二个变量');
 * @returns 格式化后的字符串
 */
sy.formatString = function (str) {
    for (var i = 0; i < arguments.length - 1; i++) {
        str = str.replace("{" + i + "}", arguments[i + 1]);
    }
    return str;
};



String.prototype.equals = function (s) {
    return this == s;
}


String.prototype.startWith = function (str) {
    var reg = new RegExp("^" + str);
    return reg.test(this);
}

String.prototype.endWith = function (str) {
    var reg = new RegExp(str + "$");
    return reg.test(this);
}

sy.mergeObj = function (o, n, override) {
    for (var p in n) if (n.hasOwnProperty(p) && (!o.hasOwnProperty(p) || override)) o[p] = n[p];
};