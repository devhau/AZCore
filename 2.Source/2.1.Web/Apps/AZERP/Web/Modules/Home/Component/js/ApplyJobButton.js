function ApplyJobButton($tagId) {
    $($tagId).find(".btn-apply-job").on("click", function () {
        alert($tagId);
    });
}