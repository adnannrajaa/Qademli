let userRole = null;
$(() => {
    userRole = GetUserRole();
    if (userRole != "Admin") {
        window.location.replace("/Account/Login/Unauthorize")
    }
    $("#GoalLi").attr("class", "active");
});
