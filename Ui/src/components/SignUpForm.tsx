import { Button, Grid, TextField, Typography } from '@mui/material';
import { SubmitHandler, useForm } from 'react-hook-form';
import IUserSignUpDto from '../types/IUserSignUpDto';
import UsersService from '../api/UsersService';
import { AxiosError } from 'axios';

const SignUpForm = () => {
    const form = useForm<IUserSignUpDto>();
    const usersService = new UsersService();

    const onSubmit: SubmitHandler<IUserSignUpDto> = (data) => {
        usersService.signUp(data).catch((e: AxiosError) => {
            const errorMessage = e.response?.data;
            if (typeof errorMessage == 'string') {
                if (
                    errorMessage.includes('Violation of UNIQUE KEY constraint')
                ) {
                    form.setError('email', {
                        type: 'manual',
                        message:
                            'This email address is already associated with an existing account.',
                    });
                }
            }
        });
    };

    return (
        <>
            <Typography
                variant="h5"
                style={{ textAlignLast: 'left', marginBottom: '20px' }}
            >
                Create your account
            </Typography>
            <form
                onSubmit={form.handleSubmit(onSubmit)}
                style={{ display: 'grid', textAlign: 'start' }}
            >
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        <TextField
                            label="Email"
                            variant="filled"
                            style={{ width: '100%' }}
                            {...form.register('email', {
                                required: 'Email is required',
                                pattern: {
                                    value: /^\S+@\S+$/i,
                                    message: 'Invalid email address',
                                },
                            })}
                            error={!!form.formState.errors.email}
                            helperText={
                                form.formState.errors.email &&
                                form.formState.errors.email.message
                            }
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            label="Password"
                            type="password"
                            variant="filled"
                            style={{ width: '100%' }}
                            {...form.register('password', {
                                required: 'Password is required',
                                // pattern: {
                                //     value: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                                //     message:
                                //         'Invalid password, must contain....',
                                // },
                            })}
                            error={!!form.formState.errors.password}
                            helperText={
                                form.formState.errors.password &&
                                form.formState.errors.password.message
                            }
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <Button
                            type="submit"
                            variant="contained"
                            color="primary"
                            style={{ width: '100%', marginTop: '16px' }}
                        >
                            Sign Up
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </>
    );
};

export default SignUpForm;
