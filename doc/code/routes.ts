export const PublicRoute = ({ children } : any) => {

    const { token } = useAppSelector(state => state.auth.user)

    return token
        ? <Navigate to="/" />
        : children
}

export const PrivateRoute = ({ children } : any) => {

    const { token } = useAppSelector(state => state.auth.user)

    return token
        ? children
        : <Navigate to="/auth" />
}