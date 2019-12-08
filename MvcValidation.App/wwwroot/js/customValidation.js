$.validator.addMethod('textMatch', function (value, element, params) {
    var txtValue = $(params[0]).val();
    console.log(txtValue);
    var expectedText = params[1];
    console.log(expectedText);

    if (!txtValue || !expectedText) {
        return false
    }

    return txtValue.toLowerCase() === expectedText.toLowerCase();
});

$.validator.unobtrusive.adapters.add('textMatch', ['expectedText'], function (options) {
    var element = $(options.form).find('input#Name');

    options.rules['textMatch'] = [element, options.params['expectedText']];
    options.messages['textMatch'] = options.message;
});