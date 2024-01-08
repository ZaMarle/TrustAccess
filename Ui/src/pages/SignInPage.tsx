import { Card, CardContent, Divider, Typography } from '@mui/material';
import { Link } from 'react-router-dom';
import SignInForm from '../components/SignInForm';

const SignInPage = () => {
    return (
        <div
            style={{
                height: '100%',
                display: 'grid',
                gridTemplateRows: '1fr auto 1fr',
            }}
        >
            <div
                style={{
                    gridRowStart: 2,
                    margin: 'auto',
                    width: '100%',
                    maxWidth: '400px',
                }}
            >
                <Card sx={{ minWidth: 275 }}>
                    <CardContent>
                        <SignInForm />
                        <Divider />
                        <div
                            style={{
                                alignItems: 'baseline',
                                display: 'flex',
                                justifyContent: 'center',
                                marginTop: '12px',
                            }}
                        >
                            <Typography style={{ marginRight: '5px' }}>
                                Don't have an account?
                            </Typography>
                            <Link to="/SignUp" style={{}}>
                                Sign Up
                            </Link>
                        </div>
                    </CardContent>
                </Card>
            </div>
        </div>
    );
};

export default SignInPage;
