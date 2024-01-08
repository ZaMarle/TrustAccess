import { Button } from '@mui/material';
import { Link } from 'react-router-dom';

const HomePage = () => {
    return (
        <div>
            <Button component={Link} to="/SignIn">
                SignIn
            </Button>
            <Button component={Link} to="/SignUp">
                SignUp
            </Button>
        </div>
    );
};

export default HomePage;
