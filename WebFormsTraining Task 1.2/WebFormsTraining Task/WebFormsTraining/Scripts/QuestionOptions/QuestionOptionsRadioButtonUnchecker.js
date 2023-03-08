$(document).ready(function () {
    $('#mainForm').submit(function (e) {

        $('.quizOptions input:radio').each(function () {
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

function OnSubmittedForm() {

    $('.quizOptions input:radio').each(function () {
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
}
