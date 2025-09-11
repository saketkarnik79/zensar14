function getUserData(id) {
    const user = {
        id,
        name: "Saket Karnik",
        role: "Partner - Delivery & Execution",
        active: true,
    };
    return `${user.name} (${user.role}) - ${user.active ? "Active" : "Inactive"}`;
}
let data = getUserData(1);
console.log(data);
export {};
//# sourceMappingURL=06-TypeScriptDemo.js.map