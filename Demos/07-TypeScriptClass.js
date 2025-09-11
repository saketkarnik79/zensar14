var UserProfile = /** @class */ (function () {
    function UserProfile(id, name, role) {
        this.id = id;
        this.name = name;
        this.role = role;
    }
    UserProfile.prototype.getSummary = function () {
        return "".concat(this.name, " (").concat(this.role, ")");
    };
    UserProfile.prototype.isExecutive = function () {
        //return this.role.includes("Partner");
    };
    return UserProfile;
}());
var saket = new UserProfile(1, "Saket Karnik", "Partner - Delivery & Execution");
console.log(saket.getSummary()); // Saket Karnik (Partner - Delivery & Execution)
//console.log(saket.isExecutive()); // true
