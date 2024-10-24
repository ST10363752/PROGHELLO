using System.Reflection;
using System.Security.Claims;
using System.Web.UI.WebControls;

@if(TempData["SuccessMessage"] != null)
{
    <div class="alert alert-success">@TempData["SuccessMessage"]</div>
}

@if(TempData["ErrorMessage"] != null)
{
    <div class="alert alert-danger">@TempData["ErrorMessage"]</div>
}

<table>
    <thead>
        <tr>
            <th>Claim ID</th>
            <th>Description</th>
            <th>Status</th>
        </tr>
    </thead>
    <tbody>
        @foreach(var claim in Model.Claims) // Ensure your model contains the list of claims
        {
            <tr>
                <td>@claim.Id</td>
                <td>@claim.Description</td>
                <td>@claim.Status</td>
            </tr>
        }
    </tbody>
</table>

