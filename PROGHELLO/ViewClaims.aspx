<table>
    <thead>
        <tr>
            <th>Claim ID</th>
            <th>Lecturer ID</th>
            <th>Total Amount</th>
            <th>Status</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var claim in Model.Claims)
        {
            <tr>
                <td>@claim.ClaimID</td>
                <td>@claim.LecturerID</td>
                <td>@claim.TotalAmount</td>
                <td>@claim.Status</td>
            </tr>
        }
    </tbody>
</table>
