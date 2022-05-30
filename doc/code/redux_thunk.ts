export const thunkLogout = (): ThunkAction<void, unknown, unknown, AnyAction> => {
    return dispatch => {
      new PersistenceService().clear()
      dispatch(authSlice.actions.logout())
      dispatch(dashboardSlice.actions.clearAll())
    }
  }