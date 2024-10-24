<<form method="post">
    <input type="text" asp-for="LecturerID" placeholder="Enter Lecturer ID" />
    <input type="text" asp-for="TotalAmount" placeholder="Enter Total Amount" />
    <button type="submit">Add Claim</button>
    <span asp-validation-summary="ModelOnly"></span>
</form>

