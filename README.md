```javascript
 <script>
    ...
    $.ajax({
        type: "POST",
        url: "/Product/InsertProduct",
        data: form,
        processData: false,
        contentType: false,
        success: (data) => {
            console.log(data);
        },
        error: (e) => {
            console.log("Erorr occured: " + e);
        }
    });
    ...
</script>
```

- **ProcessData'yı** false olarak ayarlamak, jQuery'nin verileri otomatik olarak bir sorgu dizesine dönüştürmesini önlemenizi sağlar.
- **ContentType'ın** false olarak ayarlanması zorunludur, aksi takdirde jQuery onu yanlış ayarlayacaktır.