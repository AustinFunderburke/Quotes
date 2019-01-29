'use strict';
$(document).ready(function _homeIndex() {
    $('#theQuote').html("Getting first quote...");

    // Get the first quote
    getQuote();

    // Update the quote every 3 seconds using a timer
    var timerHandle = setInterval(function _getQuote3Secs() {
        getQuote();
    }, 3000);

    // Clean up the interval timer when we navigate from the page
    $(window).on('unload', function _clearQuoteTimer() {
        clearInterval(timerHandle);
    });

    $(document).on('click', "#createQuoteBtn", function (event) {
        event.preventDefault();
        $("#createArea").show(1000);
        $("#createQuoteBtn").hide();
    });

    $("#createArea").hide();                 // hides create on the initial start up

    $(document).on('click', "#cancelQuoteCreate", function (event) {
        event.preventDefault();
        $("#createArea").hide(1000);
        $("#createQuoteBtn").show(2000);
    });
});

//create jquery function with ajax call to quote create

$(document).on("submit", "#submitQuoteCreate", function (event) {
    
    event.preventDefault();              // Prevents the default form behavior
    console.log("Hi!");                  // You have to prevent the default form action
    var $form = $(this);

    $.ajax({
        url: $form.attr("action"),       // TODO: Get the action attribute from $form
        type: $form.attr("method"),      // TODO: Get the method attribute from $form
        data: $form.serialize($form),    // TODO: Serialize $form
        success: function (response) {
            if (response === "Ok") {
                $("#createArea").hide();
                $("#createQuoteBtn").show();
            }
        },
        error: function () {
            console.log("Could not create the quote");
        }
    });
});


function getQuote() {
    $.ajax({
        url: "/quote/randomquote/",
        success: function (response) {
            let quoteInfo = response;
            $("#theQuote").fadeOut(250, function _fadeQuote() {

                // TODO: select the node with id theQuote and insert quoteInfo.theQuote
                $('#theQuote').text(quoteInfo.theQuote); // Puts the quote into the h2 tag in the Home Index view

                // TODO: fade in theQuote over 250 ms
                $('#theQuote').fadeIn(250);
            });

            $("#whoSaidIt").fadeOut(250, function _fadeWhoSaidIt() {

                // TODO: insert who said it into the element with id whoSaidIt
                $('#whoSaidIt').text(quoteInfo.whoSaidIt);

                // TODO: fade in whoSaidit over 250 ms
                $('#whoSaidIt').fadeIn(250);
            });
        },
        error: function () {

            // TODO: insert an error message into the element with id theQuote
            $('#theQuote').text("This is a error message."); 
        }
    });
};
