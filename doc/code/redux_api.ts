import { createSlice } from '@reduxjs/toolkit'

const initialState = {}

export const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    // ...
  },
  extraReducers: (builder) => {
    builder
      //Register
      .addCase(AuthActions.registerAsync.pending, (state) => {
        state.status = 'loading'
      })
      .addCase(AuthActions.registerAsync.fulfilled, (state) => {
        state.status = 'idle'
        state.messages.info = ['Review your mail box to confirm your registration']
      })
      .addCase(AuthActions.registerAsync.rejected, (state, action) => {
        state.status = 'failed'
        state.user = invalidUser
        state.errors = (action.payload) ? action.payload.errors : ['Something went wrong']
      })
  }
})