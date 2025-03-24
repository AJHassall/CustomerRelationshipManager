import { AppShell, Box, Container, Stack, useMantineColorScheme, NavLink } from '@mantine/core';
import { Link } from 'react-router-dom'; // If you're using React Router
import classes from './Layout.module.css';

export function RootLayout({ children }: { children: React.ReactNode }) {
  const { colorScheme } = useMantineColorScheme();

  const _bg = colorScheme === 'dark' ? 'dark' : 'white';

  return (
    <AppShell
      navbar={{ width: 200, breakpoint: 'sm', collapsed: { mobile: true } }} // Adjusted width
      className={classes.root}
    >
      <AppShell.Navbar className={classes.navbar}>
        <Container p="xl">
          <Stack align="stretch" justify="flex-start" gap="xs"> {/* Added spacing */}
            <NavLink component={Link} to="/contacts" label="Contacts" />
            <NavLink component={Link} to="/funds" label="Funds" />
            <NavLink component={Link} to="/assign-contacts-to-funds" label="Assign Contacts to Funds" />
          </Stack>
        </Container>
      </AppShell.Navbar>
      <AppShell.Main className={classes.content}>
        <Box style={{ zIndex: 1, position: 'relative' }} bg={_bg}>
          {children}
        </Box>
      </AppShell.Main>
    </AppShell>
  );
}