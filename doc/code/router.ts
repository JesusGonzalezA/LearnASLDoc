export const AppRouter = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route 
                    path='/auth/\*'
                    element={
                        <PublicRoute>
                            <AuthRoutes />
                        </PublicRoute>
                    }
                />

                <Route 
                    path='/\*' 
                    element={
                        <PrivateRoute>
                            <DashboardRoutes />
                        </PrivateRoute>
                    }
                />
            </Routes>
        </BrowserRouter>
    )
}