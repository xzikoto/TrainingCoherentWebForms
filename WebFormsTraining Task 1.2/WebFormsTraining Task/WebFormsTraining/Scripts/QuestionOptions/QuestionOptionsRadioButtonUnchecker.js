$(document).ready(function () {
    $('.tdrbn input:radio').click(function () {
        var tableRow = $(this).parent().parent();

        tableRow.find('input:radio').each(function () {
            $(this).prop('checked', false);
        });

        $(this).prop('checked', true)
    })

    $('#mainForm').submit(function (e) {
        $('.quizOptions .tdrbn input:radio').each(function () {
            var isChecked = false;

            var tableRow = $(this).parent().parent();

            tableRow.find('input:radio').each(function () {
                if ($(this).is(':checked') == true) {
                    isChecked = true;
                }
            });
            
            if (isChecked == false) {
                $('#MainContent_ChildContent3_RepeaterQuestions_LabelUserSelectedOption_1').attr('hidden', false);
                $('#MainContent_ChildContent3_RepeaterQuestions_LabelUserSelectedOption_1').css('color', 'red');
                e.preventDefault();
            }
            else {
                $('#MainContent_ChildContent3_RepeaterQuestions_LabelUserSelectedOption_1').attr('hidden', true);
            }
        })
    })
});