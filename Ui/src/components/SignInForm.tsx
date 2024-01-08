import { Button, Grid, TextField } from '@mui/material';
import { SubmitHandler, useForm } from 'react-hook-form';
import UsersService from '../api/UsersService';

const SignInForm = () => {
    const usersService = new UsersService();

    type Inputs = {
        email: string;
        password: string;
    };

    const form = useForm<Inputs>();

    const onSubmit: SubmitHandler<Inputs> = (data) => {
        console.log('form submitted');
        console.log(data);
        usersService.signIn(data);
    };

    return (
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
                        variant="filled"
                        style={{ width: '100%' }}
                        {...form.register('password', {
                            required: 'Password is required',
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
                        Sign In
                    </Button>
                </Grid>
            </Grid>
        </form>
    );
};

export default SignInForm;
