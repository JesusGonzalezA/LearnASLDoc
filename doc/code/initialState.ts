const invalidUser : User = {
    email: '',
    id: '',
    token: undefined
}

export const initialState: AuthState = {
  user: new PersistenceService().get('user') ?? invalidUser,
  status: 'idle',
  errors: [],
  messages: {
    info: [],
    success: []
  }
}