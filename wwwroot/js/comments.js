$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

    // Adds event called 'ReceiveMessage' to hub connection. The event will be calling from endpoint that maps with '/commentHub' specified text
    connection.on("ReceiveMessage", function (productComment) {
        let commentsWrapper = $("#comments");
        commentsWrapper.append(`
            <div class="card my-2">
                <div class="card-header">
                    `+ productComment.customerName + `
                </div>
                <div class="card-body">
                    <p class="card-text">`+ productComment.comment + ` </p>
                </div>
            </div>`);
    });

    // Starts hub connection
    connection.start().then(function () {
        showComments();
    }).catch(function (err) {
        return console.error(err.toString());
    });


    // Event listeners
    document.getElementById("addComment").addEventListener("click", (event) => {
        let comment = document.getElementById("comment").value;
        if (comment == "") {
            alert("Comment is not empty!");
            return;
        }

        $.ajax({
            url: "/Product/AddCommentToProduct",
            type: "POST",
            data: {"comment":comment},
            success: function (data) {
                if (data.isSuccess) {
                    showComments();
                    console.log(`Alinan data: ${data}`)

                    // Invokes "NotifyOtherAllClient" method specified in CommentHub class that is server side hub class
                    connection.invoke("NotifyOtherAllClient", data.productcomment).catch(function (err) {
                        return console.error(err.toString());
                    });
                }
            },
            error: function (e) {
                console.log(e);
            }
        });
        event.preventDefault();
    });

    // Methods
    function showComments() {
        $.ajax({
            url: "/Product/GetCommnetsByProduct",
            type: "GET",
            success: function (data) {
                console.log(data);
                let commentsWrapper = $("#comments");
                if(commentsWrapper.children().get().length > 0){
                    commentsWrapper.empty();
                }
                data.forEach((item, index) => {
                    commentsWrapper.append(`
                        <div class="card my-2">
                            <div class="card-header">
                                `+ item.customerName + `
                            </div>
                            <div class="card-body">
                                <p class="card-text">`+ item.comment + ` </p>
                            </div>
                        </div>`)
                });
            },
            error: function (e) {
                console.log(e);
            }
        });
    }
});