import { Card, CardContent, Divider, Typography } from '@mui/material';
import SignUpForm from '../components/SignUpForm';
import { Link } from 'react-router-dom';

const SignUpPage = () => {
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
                <Card sx={{ minWidth: 275, maxWidth: 400 }}>
                    <CardContent>
                        <SignUpForm />
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
                                Already have an account?
                            </Typography>
                            <Link to="/SignIn">Sign In</Link>
                        </div>
                    </CardContent>
                </Card>
            </div>
        </div>
    );
};

export default SignUpPage;
