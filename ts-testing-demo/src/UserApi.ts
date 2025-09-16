import {z} from 'zod';

const UserSchema= z.object({
    id: z.string(),
    name: z.string()
});

export async function fetchUser(id:string): Promise<z.infer<typeof UserSchema>> {
    const response= await fetch(`https://api.example.com/users/${id}`);
    const data= await response.json();
    return UserSchema.parse(data);   
}