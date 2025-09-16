export async function fetchUser(id: string): Promise<{id:string;name:string}>{
    //const response = await fetch(`https://jsonplaceholder.typicode.com/users/${id}`);
    const response = await fetch(`https://api.example.com/users/${id}`);
    if(!response.ok){
        throw new Error('Failed to fetch user');
    }
    return response.json();
}