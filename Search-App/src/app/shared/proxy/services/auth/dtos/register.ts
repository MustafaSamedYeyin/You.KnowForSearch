export interface Register {
    id: number;
    name: string | null;
    email: string | null;
    passwordHash: string | null;
    role: string | null;
    createdAt: string;
    updatedAt: string;
}