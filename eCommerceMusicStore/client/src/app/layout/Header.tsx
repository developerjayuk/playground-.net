import { AppBar, Box, Toolbar, Typography } from "@mui/material";
import DarkModeSwitch from "./DarkModeSwitch";

interface IProps {
  darkMode: boolean;
  toggleDarkMode: () => void;
}

export default function Header({ darkMode, toggleDarkMode }: IProps) {
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar>
        <Box sx={{ flexGrow: 1 }}>
          <Typography variant="h6">JJ's Music Store</Typography>
        </Box>
        <Box sx={{ flexGrow: 0 }}>
          <DarkModeSwitch darkMode={darkMode} toggleDarkMode={toggleDarkMode} />
        </Box>
      </Toolbar>
    </AppBar>
  );
}
